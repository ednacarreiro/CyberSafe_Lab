param([string]$BaseUrl = 'http://localhost:3000')
$ErrorActionPreference = 'Stop'
$BaseUrl = $BaseUrl.TrimEnd('/')

function Verificar($condicao, $descricao) {
  if (-not $condicao) { throw "FALHOU: $descricao" }
  Write-Host "OK: $descricao" -ForegroundColor Green
}

$health = Invoke-RestMethod "$BaseUrl/health"
Verificar ($health.status -eq 'ok') 'Health check'

$registo = Invoke-RestMethod "$BaseUrl/registo-atividade"
Verificar ([bool]$registo.config_url -and [bool]$registo.json_params_url -and [bool]$registo.user_url -and [bool]$registo.analytics_url -and [bool]$registo.analytics_list_url) 'Registo com cinco URLs'

$config = Invoke-WebRequest "$BaseUrl/configuracao-atividade.html" -UseBasicParsing
Verificar ($config.Content -match 'name="cenario"' -and $config.Content -match 'name="resumo"') 'Página HTML de configuração'

$params = Invoke-RestMethod "$BaseUrl/json-params-atividade"
Verificar ($params.Count -eq 4 -and 'cenario' -in $params.name) 'Quatro parâmetros de configuração'

$body = @{ activityID = 'turma-2026-01' } | ConvertTo-Json
$deploy = Invoke-RestMethod -Uri "$BaseUrl/deploy-atividade" -Method Post -ContentType 'application/json' -Body $body
Verificar ($deploy -like '*/atividade/turma-2026-01') 'Deploy devolve URL da futura atividade'

$available = Invoke-RestMethod "$BaseUrl/lista-analytics-atividade"
Verificar ($available.qualAnalytics.Count -eq 2 -and $available.quantAnalytics.Count -eq 2) 'Lista de analytics'

$analytics = Invoke-RestMethod -Uri "$BaseUrl/analytics-atividade" -Method Post -ContentType 'application/json' -Body $body
Verificar ($analytics.Count -eq 2 -and $analytics[0].inveniraStdID -eq 'demo-aluno-1001') 'Analytics fictícios'

try {
  Invoke-WebRequest "$BaseUrl/atividade/turma-2026-01" -UseBasicParsing | Out-Null
  throw 'FALHOU: Provide activity não pode estar implementado.'
} catch {
  if ($_.Exception.Message -like 'FALHOU:*') { throw }
  $status = [int]$_.Exception.Response.StatusCode
  Verificar ($status -eq 404) 'Provide activity ainda não implementado (404)'
}

Write-Host 'Todos os testes HTTP passaram.' -ForegroundColor Green
