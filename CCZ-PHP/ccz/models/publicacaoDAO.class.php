<?php
    class PublicacaoDAO extends Conexao{
        public function __construct(){
            parent::__construct();
        }

        public function inserirPublicacao($publicacao){
            $sql = "INSERT INTO publicacoes (data_publicacao, titulo_publicacao, fk_id_funcionario, conteudo_publicacao, imagem_publicacao) VALUES (?, ?, ?, ?, ?)";
            try{
                $stm = $this->db->prepare($sql);
                $stm->bindValue(1, $publicacao->getDataPublicacao());
                $stm->bindValue(2, $publicacao->getTituloPublicacao());
                $stm->bindValue(3, $publicacao->getFuncionario());
                $stm->bindValue(4, $publicacao->getDescricao());
                $stm->bindValue(5, $publicacao->getFoto());
                $stm->execute();
                $this->db = null;
                return "Publicação cadastrada com sucesso!";
            } catch (PDOException $e){
                echo $e->getCode();
                echo $e->getMessage();
                die();
            }

        }

        private function getFuncionario($funcionario) {
            $sql = "SELECT * FROM funcionarios WHERE id = ?"; 
            try {
                $stm = $this->db->prepare($sql);
                $stm->bindValue(1, $funcionario);
                $stm->execute();
                $this->db = null;
                return $stm->fetchAll(PDO::FETCH_OBJ);
            } catch (Exception $e) {
                die("Erro: " . $e->getMessage());
            }
        }
    }
?>