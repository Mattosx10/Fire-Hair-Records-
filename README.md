# 🎵 FireHair Records

Sistema de locação de álbuns desenvolvido em **C#**, com foco na aplicação de conceitos de **Programação Orientada a Objetos (POO)** e lógica de programação.

O projeto simula o funcionamento de uma loja de aluguel de álbuns físicos, permitindo cadastrar clientes, realizar locações, controlar estoque, registrar pagamentos, calcular multas por atraso e consultar informações das locações.

> 🚀 Projeto desenvolvido como parte do meu processo de aprendizado em C# e Programação Orientada a Objetos.

---

## 📌 Sobre o projeto

O **FireHair Records** foi desenvolvido com o objetivo de colocar em prática conceitos fundamentais da programação utilizando C#.

Durante o desenvolvimento, foram aplicados conceitos como:

* Programação Orientada a Objetos
* Classes e objetos
* Encapsulamento
* Construtores
* Atributos privados
* Métodos
* Getters e Setters
* Listas (`List<T>`)
* Estruturas condicionais
* Estruturas de repetição
* Validação de dados
* Manipulação de datas com `DateTime`
* Tratamento de entradas com `TryParse`
* Relacionamento entre objetos
* Regras de negócio

O sistema foi desenvolvido inicialmente de forma simples e evoluído conforme novas regras e funcionalidades foram implementadas.

---

## ⚙️ Funcionalidades

### 👤 Cadastro de clientes

Permite cadastrar clientes informando:

* ID
* Nome
* Telefone
* E-mail
* Endereço

O sistema possui validações para:

* Nome vazio ou inválido
* Nome contendo caracteres não permitidos
* Telefone com formato inválido
* Telefone com menos de 10 dígitos
* E-mail sem `@` ou `.` .

---

### 💿 Gerenciamento de álbuns

Cada álbum possui:

* ID
* Nome
* Artista
* Ano de lançamento
* Estilo musical
* Quantidade disponível em estoque

O sistema controla automaticamente o estoque durante as locações e devoluções.

---

### 🎵 Estilos musicais

Os álbuns podem ser associados a um estilo musical.

Atualmente, o projeto utiliza objetos da classe `EstiloMusical` para representar essa informação.

---

### 📦 Realização de locações

Para realizar uma locação, o sistema verifica:

* Se o cliente existe
* Se o cliente está bloqueado
* Se o cliente já possui uma locação ativa
* Se o álbum possui estoque disponível

Após a confirmação da locação, a quantidade disponível do álbum é reduzida.

---

### 💰 Valor da locação

O valor inicial de uma locação é de **R$ 20,00**.

A cada **6 anos completos desde o lançamento do álbum**, é aplicado um desconto de **R$ 2,00**.

O valor mínimo da locação é de **R$ 8,00**.

Exemplo:

| Idade do álbum  |        Valor da locação |
| --------------- | ----------------------: |
| Menos de 6 anos |                R$ 20,00 |
| 6 a 11 anos     |                R$ 18,00 |
| 12 a 17 anos    |                R$ 16,00 |
| 18 a 23 anos    |                R$ 14,00 |
| 24 anos ou mais | Até o mínimo de R$ 8,00 |

---

### 📅 Prazo de devolução

Cada locação possui um prazo de **7 dias** para devolução.

O sistema registra:

* Data da locação
* Data prevista para devolução
* Data efetiva da devolução

---

### ⚠️ Multa por atraso

Caso o álbum seja devolvido após a data prevista, é calculada uma multa de:

**10% do valor da locação por dia de atraso.**

Exemplo:

> Valor da locação: R$ 10,00
> Atraso: 2 dias
> Multa: R$ 2,00

A multa fica registrada na locação e pode ser paga posteriormente.

---

### 🔒 Bloqueio de clientes

Quando uma multa permanece pendente após uma devolução atrasada, o cliente fica bloqueado para novas locações.

Enquanto estiver bloqueado, o cliente não pode realizar uma nova locação.

Após o pagamento da multa, o cliente é desbloqueado.

---

### 💳 Pagamentos

O sistema possui controle separado para:

* Pagamento do aluguel
* Pagamento da multa

Também impede que um pagamento já realizado seja registrado novamente.

---

### 🔎 Consultas

É possível consultar:

* Locações de um determinado cliente
* Locações ativas
* Detalhes de uma locação específica
* Status da locação
* Valor da locação
* Valor da multa, quando aplicável
* Datas de locação e devolução

---

## 📋 Status das locações

As locações podem assumir diferentes estados:

| Status       | Descrição                                  |
| ------------ | ------------------------------------------ |
| `Ativa`      | Locação ainda em andamento                 |
| `Pendente`   | Álbum devolvido, mas existe multa pendente |
| `Finalizada` | Locação encerrada e sem pendências         |

---

## 🏗️ Estrutura do projeto

O projeto é organizado em diferentes classes, cada uma representando uma responsabilidade do sistema.

```text
FireHair Records
│
├── Program.cs
├── Cliente.cs
├── Album.cs
├── EstiloMusical.cs
├── Locacao.cs
└── SistemaLocacao.cs
```

### `Cliente`

Responsável pelas informações e regras relacionadas aos clientes.

### `Album`

Representa os álbuns disponíveis para locação e controla seu estoque.

### `EstiloMusical`

Representa o estilo musical associado a cada álbum.

### `Locacao`

Representa uma locação e concentra informações como datas, valores, pagamentos, multas e status.

### `SistemaLocacao`

Responsável pelo gerenciamento das locações e aplicação de regras relacionadas ao processo de aluguel.

### `Program`

Responsável pela interação com o usuário através do console e pelo menu principal do sistema.

---

## 🧠 Conceitos aplicados

Durante o desenvolvimento, foram praticados conceitos importantes de C# e POO.

### Encapsulamento

Os atributos das classes são privados e o acesso aos dados é realizado através de métodos.

```csharp
private string nome;
private string telefone;
private string email;
```

### Construtores

Os construtores são utilizados para inicializar os objetos com seus dados necessários.

### Relacionamento entre objetos

A classe `Locacao`, por exemplo, possui referências para objetos `Cliente` e `Album`.

```text
Locacao
 ├── Cliente
 └── Album
```

### Coleções

O sistema utiliza `List<T>` para armazenar clientes, álbuns e locações.

### Validação

As entradas fornecidas pelo usuário são validadas antes de serem utilizadas pelo sistema.

### Controle de fluxo

Foram utilizados recursos como:

* `if / else`
* `switch`
* `do / while`
* `foreach`
* `continue`
* `break`

### Tratamento de entrada

O `int.TryParse()` é utilizado para evitar erros quando o usuário informa valores que deveriam ser numéricos.

---

## 🛠️ Tecnologias utilizadas

* **C#**
* **.NET**
* **Visual Studio / Visual Studio Code**
* **Git**
* **GitHub**

---

## ▶️ Como executar

### 1. Clone o repositório

```bash
git clone URL_DO_SEU_REPOSITORIO
```

### 2. Abra o projeto

Abra o projeto utilizando o **Visual Studio** ou uma IDE compatível com C# e .NET.

### 3. Execute a aplicação

Execute o projeto para iniciar o sistema através do console.

---

## 🧪 Testes realizados

Após a implementação, foram realizados testes dos principais fluxos do sistema, incluindo cenários de sucesso e situações de erro.

### Cadastro

* Cadastro válido
* Nome inválido
* E-mail inválido
* Telefone inválido

### Locação

* Cliente existente
* Cliente inexistente
* Cadastro de cliente durante o processo de locação
* Álbum disponível
* Álbum sem estoque
* Cliente com locação ativa
* Cliente bloqueado

### Pagamentos

* Pagamento do aluguel
* Tentativa de pagamento duplicado
* Pagamento de multa
* Tentativa de pagamento duplicado

### Devoluções

* Devolução dentro do prazo
* Devolução na data prevista
* Devolução atrasada
* Cálculo da multa
* Multa paga
* Multa pendente

### Bloqueio

* Cliente bloqueado tentando realizar locação
* Pagamento da multa
* Desbloqueio do cliente
* Nova locação após o desbloqueio

### Consultas

* Listagem de locações do cliente
* Listagem de locações ativas
* Consulta dos detalhes de uma locação
* Busca de locações inexistentes

---

## 📚 Aprendizados

O desenvolvimento deste projeto foi uma oportunidade para transformar conceitos estudados em um sistema funcional.

Entre os principais aprendizados estão:

* Estruturar um projeto utilizando POO
* Criar classes com responsabilidades diferentes
* Trabalhar com objetos relacionados
* Criar e aplicar regras de negócio
* Validar entradas do usuário
* Trabalhar com listas
* Manipular datas
* Criar fluxos de pagamento e devolução
* Identificar e corrigir erros durante o desenvolvimento
* Testar diferentes cenários antes de considerar o sistema concluído

---

## 🚀 Próximos passos

Algumas melhorias podem ser implementadas futuramente, como:

* Persistência de dados em banco de dados
* Interface gráfica
* Sistema de login para funcionários
* Histórico mais detalhado de clientes
* Relatórios
* Melhorias na arquitetura do projeto
* Integração com banco de dados
* Testes automatizados

> Essas funcionalidades fazem parte de possíveis evoluções futuras e não estão presentes na versão atual do projeto.

---

## 👨‍💻 Autor

**João Matos**

Estudante de **Análise e Desenvolvimento de Sistemas** e desenvolvedor em formação, atualmente aprofundando meus conhecimentos em **C#, Java, Programação Orientada a Objetos e lógica de programação**.

Buscando minha primeira oportunidade na área de tecnologia e constantemente desenvolvendo projetos para colocar meus conhecimentos em prática.

---

⭐ Se este projeto foi útil ou interessante para você, fique à vontade para deixar uma estrela no repositório!

