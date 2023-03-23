# SecLog
A aplicação tem como objetivo ler um arquivo de log txt e tratar esses dados recebido atraves de uma API,
depois disso é armazenado em um banco de dados MySQL, e consumido pela parte do Front feito em react com TypeScript

## Funções do Projeto
#### OBS.: todas as consultas possuem a possibilidade de limitar o total de registros retornados devido a quantidade de registros, no front esta limitado em 100
* ```/importlog```
 -> Ao chamar essa requisição do tipo POST a API chama o metodo SaveLogContent() que na dominio de aplicação chama o metodo ReadLogFile()
 que é responsavel por ler o arquivo que se encontra dentro da pasta Upload, tratar os dados e jogar no LogModel, apos isso o Metodo SaveLogContent()
 salva todas as informações tratadas no banco de dados
 
* ```/GetItemsLogByLimit/{limit}```
 -> Lista o conteudo do banco com **limite**
 
* ```/GetItemsByInterval/{startDate}/{endDate}/{limit}```
 -> Lista o conteudo do banco pelo intervalo de data e **limite**
 
* ```/GetItemsByDescription/{description}/{limit}```
 -> Lista o conteudo do banco pela descrioção do tipo contains e **limite**
 
* ```/GetItemsByIpServer/{ipServer}/{limit}```
 -> Lista o conteudo do banco pelo servidor e **limite**
 
 * ```/GetItemsByProcess/{process}/{limit}```
 -> Lista o conteudo do banco pelo processo e **limite**
 
