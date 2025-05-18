<?php
    class Pessoa {
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
            protected string $perfil = ''
        ){}

        public function getId(){
            return $this->id;
        }

        public function setId($id){
           $this->id = $id;
        }

        public function getNome(){
            return $this->nome;
        }

        public function setNome($nome){
           $this->nome = $nome;
        }

        public function getSobrenome(){
            return $this->sobrenome;
        }

        public function setSobrenome($sobrenome){
           $this->sobrenome = $sobrenome;
        }

        public function getCpf(){
            return $this->cpf;
        }

        public function setCpf($cpf){
           $this->cpf = $cpf;
        }

        public function getDatanasc(){
            return $this->datanasc;
        }

        public function setDatanasc($datanasc){
           $this->datanasc = $datanasc;
        }

        public function getSexo(){
            return $this->sexo;
        }

        public function setSexo($sexo){
           $this->sexo = $sexo;
        }

        public function getEmail(){
            return $this->email;
        }

        public function setEmail($email){
           $this->email = $email;
        }

        public function getSenha(){
            return $this->senha;
        }

        public function setSenha($senha){
           $this->senha = $senha;
        }

        public function getTelefone(){
            return $this->telefone;
        }

        public function setTelefone($telefone){
           $this->telefone = $telefone;
        }

        public function getPerfil(){
            return $this->perfil;
        }

        public function setPerfil($perfil){
           $this->perfil = $perfil;
        }
    }
?>