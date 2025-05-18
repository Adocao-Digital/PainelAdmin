<?php
    class Animais{
        public function __construct(
            protected int $id = 0,
            protected string $nome = '',
            protected string $especie = '',
            protected string $idade = '',
            protected string $sexo = '',
            protected string $foto = '',
            protected string $porte = ''
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

        public function getEspecie(){
            return $this->especie;
        }

        public function setEspecie($especie){
           $this->especie = $especie;
        }

        public function getIdade(){
            return $this->idade;
        }

        public function setIdade($idade){
           $this->idade = $idade;
        }

        public function getSexo(){
            return $this->sexo;
        }

        public function setSexo($sexo){
           $this->sexo = $sexo;
        }

        public function getPorte(){
            return $this->peso;
        }

        public function setPorte($porte){
           $this->peso = $porte;
        }

        public function getFoto(){
            return $this->foto;
        }

        public function setFoto($foto){
           $this->foto = $foto;
        }
    }
?>