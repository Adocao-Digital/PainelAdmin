<?php
    class Publicacao{
        public function __construct(
            private int $id = 0,
            private string $titulo = '',
            private string $descricao = '',
            private string $data = '',
            private string $foto = '',
            private $funcionario = ''
        ){}

        public function getId(){
            return $this->id;
        }

        public function setId($id){
           $this->id = $id;
        }

        public function getTitulo(){
            return $this->titulo;
        }

        public function setTitulo($titulo){
           $this->titulo = $titulo;
        }

        public function getDescricao(){
            return $this->descricao;
        }

        public function setDescricao($descricao){
           $this->descricao = $descricao;
        }

        public function getData(){
            return $this->data;
        }

        public function setData($data){
           $this->data = $data;
        }

        public function getFoto(){
            return $this->foto;
        }

        public function setFoto($foto){
           $this->foto = $foto;
        }

        public function getFuncionario(){
            return $this->funcionario;
        }

        public function setFuncionario($funcionario){
           $this->funcionario = $funcionario;
        }
    }
?>