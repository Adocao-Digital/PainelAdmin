<?php
    class PetadocaoDAO extends Conexao {
        public function __construct(){
            parent::__construct();
        }

        public function inserirPetadocao($petadocao){
            $sql = "INSERT INTO petadocao (nome_petAdocao, foto_petAdocao, descricao_petAdocao, status_petAdocao, especie_petAdocao, idade_petAdocao, porte_petAdocao, sexo_petAdocao) VALUES (?, ?, ?, ?, ?, ?, ?, ?)";
            try{
                $stm = $this->db->prepare($sql);
                $stm->bindValue(1, $petadocao->getNome());
                $stm->bindValue(2, $petadocao->getFoto());
                $stm->bindValue(3, $petadocao->getDescricao());
                $stm->bindValue(4, $petadocao->getStatus());
                $stm->bindValue(5, $petadocao->getEspecie());
                $stm->bindValue(6, $petadocao->getIdade());
                $stm->bindValue(7, $petadocao->getPorte());
                $stm->bindValue(8, $petadocao->getSexo());
                $stm->execute();
                $this->db = null;
                return "Pet cadastrado com sucesso!";
            }catch (PDOException $e) {
                echo $e->getCode();
                echo $e->getMessage();
                die();
            }
        }

        public function listarPetadocao(){
            $sql = "SELECT * FROM petadocao WHERE status_petAdocao = 'Disponível'";
            try{
                $stm = $this->db->prepare($sql);
                $stm->execute();
                $this->db = null;
                return $stm->fetchAll(PDO::FETCH_OBJ);
            }catch (PDOException $e){
                echo $e->getCode();
                echo $e->getMessage();
                die();
            }
        }
    }
?>