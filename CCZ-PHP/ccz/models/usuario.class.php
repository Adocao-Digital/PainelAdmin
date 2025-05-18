<?php
class Usuario extends Pessoa {
    public function __construct(
        protected int $id = 0,
        protected string $nome = '',
        protected string $sobrenome = '',
        protected string $cpf = '',
        protected string $datanasc = '',
        protected string $sexo='',
        protected string $email = '',
        protected string $senha = '',
        protected string $telefone = '',
        protected string $perfil = '')
        {
            parent::__construct($id, $nome, $sobrenome, $cpf,$datanasc, $sexo, $email, $senha, $telefone, $perfil);
        }
}
?>