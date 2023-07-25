# Redis

[Voltar](../README.md)

## Conceitos

- [Sync vs Async vs Fire-and-Forget](https://stackexchange.github.io/StackExchange.Redis/Basics#sync-vs-async-vs-fire-and-forget)
	- Synchronous: Aguardar retorno do servidor para seguir execu��o do c�digo
	- Asynchronous: Padr�o .net para reaproveitamento de threads
	- Fire-and-Forget: Executa opera��o e n�o aguarda retorno. Se ocorrer erro, n�o ser� interrompida a aplica��o. Usar com muito cuidado!
- Contadores
	- ZSet / Sorted: Contador double ordenado descrescente
	- Hash: Contator com chave/valor interno (Equivalente a um dicion�rio)
	- Simple: Chave/Valor simples
- Conex�o Thread safe, pode ser compartilhando a mesma conex�o entre threads distintas
- Quando h� muita opera��o assincrona (valores gigantes de burst test > 10.000 ops/sec, pode travar descarregamento de fila)