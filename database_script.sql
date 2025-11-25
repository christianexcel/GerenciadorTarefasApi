-- Tabela de Usuários (Exemplo de entidade principal)
CREATE TABLE "TB_USUARIOS" (
"id_usuario" SERIAL PRIMARY KEY,
"nome_usuario" VARCHAR(100) NOT NULL,
"email_usuario" VARCHAR(150) NOT NULL UNIQUE
);
-- Tabela de Tarefas (Relacionamento 1:N com Usuario)
CREATE TABLE "TB_TAREFAS" (
"id_tarefa" SERIAL PRIMARY KEY,
"titulo_tarefa" VARCHAR(100) NOT NULL,
"descricao_tarefa" VARCHAR(500) NULL,
"data_criacao" TIMESTAMP WITH TIME ZONE NOT NULL,
"data_conclusao" TIMESTAMP WITH TIME ZONE NULL,
"concluida" BOOLEAN NOT NULL DEFAULT false,
"id_usuario" INT NOT NULL, -- Chave Estrangeira para Usuario
CONSTRAINT "fk_usuario_tarefa" FOREIGN KEY ("id_usuario") REFERENCES
"TB_USUARIOS"("id_usuario")
);
-- Tabela de Detalhes da Tarefa (Relacionamento 1:1 com Tarefa)
CREATE TABLE "TB_DETALHES_TAREFA" (
"id_tarefa" INT PRIMARY KEY, -- Mesma chave primária de Tarefas
"prioridade" INT NOT NULL DEFAULT 0, -- Ex: 0=Baixa, 1=Média, 2=Alta
"notas_adicionais" TEXT NULL,
CONSTRAINT "fk_tarefa_detalhes" FOREIGN KEY ("id_tarefa") REFERENCES
"TB_TAREFAS"("id_tarefa") ON DELETE CASCADE -- Se deletar a tarefa, deleta os detalhes
);
-- Tabela de Tags
CREATE TABLE "TB_TAGS" (
"id_tag" SERIAL PRIMARY KEY,
"nome_tag" VARCHAR(50) NOT NULL UNIQUE
);
-- Tabela de Junção Tarefa <-> Tag (Relacionamento N:N)
CREATE TABLE "TB_TAREFAS_TAGS" (
"id_tarefa" INT NOT NULL,
"id_tag" INT NOT NULL,
PRIMARY KEY ("id_tarefa", "id_tag"),
CONSTRAINT "fk_tarefatag_tarefa" FOREIGN KEY ("id_tarefa") REFERENCES
"TB_TAREFAS"("id_tarefa") ON DELETE CASCADE,
CONSTRAINT "fk_tarefatag_tag" FOREIGN KEY ("id_tag") REFERENCES
"TB_TAGS"("id_tag") ON DELETE CASCADE
);
-- Dados Iniciais (Opcional, mas útil para testes)
INSERT INTO "TB_USUARIOS" ("nome_usuario", "email_usuario") VALUES ('Admin User', 
'admin@tarefas.com');
INSERT INTO "TB_TAGS" ("nome_tag") VALUES ('Trabalho'), ('Pessoal'), ('Urgente')