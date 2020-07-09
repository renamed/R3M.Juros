# R3M.Juros

## Disclaimer
Modifiquei os nomes dos _endpoints_, retirando verbos e substantivos grandes demais nos nomes, conforme boas práticas.

## Rodando os testes

### Testes de Unidade
O microsserviço _Indicadores_ não possui regras de negócio, e é simples demais. Por esse motivo não possui testes de unidade.
Para rodar os testes de unidade no microsserviço _Financeiro_, faça o seguinte:
- Acesse a raiz do projeto com o _cmd_ ou _terminal_
- Digite os comandos abaixo e dê ênter, um de cada vez
```sh 
 $ cd Financeiro/tests
 $ dotnet test
```
- O resultado dos testes aparecerá na tela
- [https://pasteboard.co/JgNhrfT.png](https://pasteboard.co/JgNhrfT.png)

### Teste de Integração

- Acesse a raiz do projeto com o _cmd_ ou _terminal_
- Digite os comandos abaixo e dê ênter, um de cada vez
```sh
$ docker-compose up -d --build 
$ cd IntegrationTests/
$ dotnet test
```
- O resultado dos testes aparecerá na tela
- [https://pasteboard.co/JgNlgrW.png](https://pasteboard.co/JgNlgrW.png)
- Por fim, digite os comandos abaixo e dê ênter, um de cada vez
```sh
$ docker-compose stop
$ docker-compose down
```

## Rodando a aplicação
- Acesse a raiz do projeto com o _cmd_ ou _terminal_
- Digite os comandos abaixo e dê ênter, um de cada vez
```sh
$ docker-compose up -d --build 
```
- Para acessar o Swagger do Microsserviço de _Indicadores_, acesse [http://localhost:7666/swagger/index.html](http://localhost:7666/swagger/index.html)
- Para acessar o Swagger do Microsserviço de _Financeiro_, acesse [http://localhost:8666/swagger/index.html](http://localhost:8666/swagger/index.html)
- Ao término, rode
```sh
$ docker-compose stop
$ docker-compose down
```