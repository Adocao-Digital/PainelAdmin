<?php
    class Petadocao{
        public function __construct(
            protected int $id = 0,
            protected string $nome = '',
            protected string $especie = '',
            protected string $idade = '',
            protected string $sexo = '',
            private string $peso = '',
            protected string $foto = '',
            private string $descricao = '',
            private string $status = ''
        ){
            parent::__construct($id, $nome, $especie, $idade, $sexo, $foto);
        }

        public function getDescricao(){
            return $this->descricao;
        }

        public function setDescricao($descricao){
            $this->descricao = $descricao;
        }

        public function getStatus(){
            return $this->status;
        }

        public function setStatus($status){
            $this->status = $status;
        }
    }
?>