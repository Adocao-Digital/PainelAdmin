<?php
    class Funcionario extends Pessoa {
        public function __construct(
            protected int $id = 0,
            protected string $nome = '',
            protected string $sobrenome = '',
            protected string $cpf = '',
            private string $dataAdmissao = '',
            protected string $datanasc = '',
            protected string $sexo='',
            protected string $email = '',
            protected string $senha = '',
            protected string $telefone = '',
            protected string $perfil = '')
        {
            parent::__construct($id, $nome, $sobrenome, $cpf, $datanasc, $sexo, $email, $senha, $telefone, $perfil);
        }

        public function getDataAdmissao(){
            return $this->dataAdmissao;
        }

        public function setDataAdmissao($dataAdmissao){
            $this->dataAdmissao = $dataAdmissao;
        }
    }
?>