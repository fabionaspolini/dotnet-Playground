# Jaeger

Modelo de representa��o do Jaeger � inspirado no Open Tracing, sendo muito similar, apenas com nomenclaturas diferentes ([Detalhes](https://www.jaegertracing.io/docs/1.47/architecture/#terminology)).

Depende de instrumenta��es explicitas no c�digo fonte, onde para cada componente t�cnico � necess�rio configura��es (Ex.: HttpClient, Driver de acesso a DB, Entity Framework, etc).

***Os SDKs do Jaeger foram todos depreciados. A recomenda��o � utilizar SDK's no formato OTLP - OpenTelemetry Protocol.***

## Componentes do servi�o

Lista oficial de [componentes](https://www.jaegertracing.io/docs/architecture/#components) e [downloads](https://www.jaegertracing.io/download).

- **jaeger-agent [Deprecated]**: Recebe spans dos clientes Jaeger e encaminha para o coletor. Projetado para ser executado como sidecar ou host agent.  
   ***Deprecated info***: Dados no formato OpenTelemetry devem ser enviados diretamente para o backend Jaeger ou para OpenTelemetry Collector pode ser utilizado como agent.
- **jaeger-collector**: Recebe spans de agentes ou diretamente de clientes e os salva em armazenamento persistente (Nos formatos OpenTelemetry e Jaeger).
- **jaeger-query**: Serve Jaeger UI e uma API que recupera rastreamentos do armazenamento.
- **jaeger-ingester**: Uma alternativa ao coletor; l� spans do t�pico Kafka e os salva no armazenamento.
- **jaeger-remote-storage**: Um servi�o que implementa a API de armazenamento remoto em cima de outro back-end compat�vel.
  Pode ser usado para compartilhar um back-end de armazenamento de n� �nico, como mem�ria, em v�rios processos Jaeger.
- **jaeger-operator**: Um Kubernetes Operator para empacotar, implantar e gerenciar a instala��o do Jaeger.


SDK's podem ser configurados para enviar dados para o "Open Telemetry Collector".

## Amostragem da coleta

[Documenta��o oficial.](https://www.jaegertracing.io/docs/sampling/)

Configura��o sobre coleta de amostras.


## Local server all-in-one

```bash
docker run -d --name jaeger \
  -e COLLECTOR_ZIPKIN_HOST_PORT=:9411 \
  -e COLLECTOR_OTLP_ENABLED=true \
  -p 6831:6831/udp \
  -p 6832:6832/udp \
  -p 5778:5778 \
  -p 16686:16686 \
  -p 4317:4317 \
  -p 4318:4318 \
  -p 14250:14250 \
  -p 14268:14268 \
  -p 14269:14269 \
  -p 9411:9411 \
  jaegertracing/all-in-one:1.47
```

Jaeger UI: <http://localhost:16686>

Lista de cada endpoint: <https://www.jaegertracing.io/docs/1.47/getting-started/#all-in-one>

```
docker run \
  --rm \
  --link jaeger \
  --env OTEL_EXPORTER_JAEGER_ENDPOINT=http://jaeger:14268/api/traces \
  -p8080-8083:8080-8083 \
  jaegertracing/example-hotrod:latest \
  all
```

docker run --rm -d -p 9411:9411 --name zipkin openzipkin/zipkin

docker run --rm -d -p 9511:9411 --name zipkin openzipkin/zipkin
