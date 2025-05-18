<?php
    class Petusuario{
        public function __construct(
            protected int $id = 0,
            protected string $nome = '',
            protected string $especie = '',
            protected string $idade = '',
            protected string $sexo = '',
            protected string $porte = '',
            private string $peso = '',
            protected string $foto = ''
        ){
            parent::__construct($id, $nome, $especie, $idade, $sexo, $porte, $foto);
        }

        public function getPeso(){
            return $this->peso;
        }

        public function setPeso($peso){
            $this->peso = $peso;
        }
    }
?>