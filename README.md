Atualmente, estou em busca de desafios e testes para vagas de desenvolvedores, visando aprimorar minhas habilidades em programação. Encontro esses desafios e testes como oportunidades valiosas para aplicar e expandir meu conhecimento. Ao abordar cada desafio, concentro-me em compreender completamente os requisitos e as expectativas, esforçando-me para completá-los de acordo com as diretrizes fornecidas e respeitando meu nível atual de habilidades. Encaro cada tarefa como uma chance de aprendizado e aprimoramento, buscando constantemente superar desafios e progredir na minha jornada como desenvolvedor.

Este desafio foi proposto pela SeniorSA. A aplicação é uma API para marcação de hórarios, porém o ponto principal dessa aplicação é atender o cenário em que na grande maioria as marcações acontecem em um intervalo de tempo muito curto, cerca de cinco minutos. E esse problema
é potencializado em um cenário em que muitas empresas usam essa mesma aplicação. 

Neste cenário, foi desenvolvido uma API que consiga atender este cenário da maneira mais agradável possível, mesmo neste cenário problemático dito no desafio.

Para isso, eu criei uma API feita com .NET 7 e como um PLUS eu desenvolvi também um aplicativo feito em React Native para realizar as marcações.

Para API eu segui alguns conceitos que acredito que sejam de extrema importancia para que a aplicação atenda seu propósito sem grandes problemas. Abaixo é possível identificar o que foi feito na aplicação:

<strong>Clean Architecture<strong/>:

Facilita a manutenção e testabilidade ao organizar o código em camadas bem definidas, promovendo a separação de responsabilidades.
CQRS (Command Query Responsibility Segregation):

Melhora o desempenho ao separar operações de leitura e escrita, permitindo otimizações específicas para cada tipo de operação.
Rate Limit:

Protege sua API contra abusos, controlando o número de requisições que um cliente pode fazer em um determinado período de tempo.
Cache de Memória:

Aumenta a eficiência ao armazenar temporariamente dados frequentemente acessados em memória, reduzindo a necessidade de acessar o armazenamento persistente.
SOLID:

Promove a construção de um código modular, flexível e fácil de entender, contribuindo para uma base sólida e extensível.
MongoDB:

Oferece escalabilidade e flexibilidade no esquema de dados, sendo uma escolha adequada para armazenamento de dados em aplicações modernas.
Padrão Repository:

Abstrai o acesso a dados, fornecendo uma interface consistente para interagir com o armazenamento de dados, facilitando a manutenção e testes.
DTO (Data Transfer Object):

Melhora a eficiência da comunicação entre camadas da aplicação ao transferir apenas os dados necessários, evitando excesso de informações.
Modelo Rico:

Enriquece a representação dos objetos de domínio ao incorporar lógica de negócios, contribuindo para uma modelagem mais expressiva e consistente.
Mediator:

Facilita a comunicação entre componentes, promovendo o baixo acoplamento e permitindo que diferentes partes da aplicação enviem comandos ou publiquem eventos sem conhecimento direto dos detalhes de implementação umas das outras.

Esta api conta com três endpoints:
- Um para marcação de ponto
- Um para listar todos os pontos feitos por um funcionário
- Um endpoint para listar todas as marcações que os funcionários fizeram em uma empresa

Cada um desses endpoints contam com um comand para realizar suas respectivas ações dentro da aplicação.
