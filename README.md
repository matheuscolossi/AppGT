  🧭 *Sobre o Projeto*

GearTrack é um software desktop desenvolvido em C# (.NET Framework) com SQL Server, criado para gerenciar lojas de esportes e lazer.
O sistema centraliza e automatiza processos como cadastro de produtos, clientes, fornecedores, compras e vendas, além de gerar relatórios gerenciais que auxiliam na tomada de decisões estratégicas.

O projeto foi desenvolvido como parte do Projeto Integrador III do curso de Ciência da Computação na URI Erechim, aplicando princípios de Engenharia de Software, Modelagem de Dados Relacional e Padrões de Projeto.

  ⚙️ *Funcionalidades Principais*

Cadastro e gerenciamento de produtos, clientes, fornecedores, marcas e categorias

Controle de estoque automático após compras e vendas

Registro de vendas e compras com cálculo de totais e atualização de estoque

Geração de relatórios gerenciais (vendas por período, produtos mais vendidos, fluxo de caixa)

Controle de acesso por níveis de usuário (administrador, vendedor, operador de estoque)

Login seguro com senhas criptografadas

Interface intuitiva e responsiva para desktop

  🧩 *Tecnologias Utilizadas*

C# (Windows Forms)

SQL Server

Microsoft.Data.SqlClient

Git / GitHub para controle de versão

Padrão Repository para separar lógica de dados e regras de negócio

  🧠 *Arquitetura e Estrutura*

O projeto segue uma arquitetura em camadas, com separação entre:

Camada de Apresentação: formulários (Windows Forms) para interação do usuário.

Camada de Negócio: regras e validações do sistema.

Camada de Dados: integração segura com o banco via SQL Server.

Cada módulo (Clientes, Produtos, Fornecedores, Vendas, etc.) possui formulários e classes específicos, facilitando a manutenção e escalabilidade.

  🔒 *Segurança e Conformidade*

Senhas criptografadas no banco de dados.

Validação automática de CPF e CNPJ.

Logs de auditoria para acessos inválidos.

Conformidade com a LGPD (Lei Geral de Proteção de Dados).
