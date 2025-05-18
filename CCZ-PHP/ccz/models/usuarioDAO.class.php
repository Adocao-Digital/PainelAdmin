<?php
class UsuarioDAO extends ConexaoMongo {
    public function __construct(){
        parent::__construct();
    }

    // Método para inserir um novo usuário no MongoDB
    public function inserir($usuario){
        try {
            // Seleciona a coleção 'usuarios'
            $collection = $this->db->Usuarios;

            // Cria o documento a ser inserido
            $document = [
                'nome_usuario' => $usuario->getNome(),
                'sobrenome_usuario' => $usuario->getSobrenome(),
                'datanasc_usuario' => $usuario->getDatanasc(),
                'cpf_usuario' => $usuario->getCpf(),
                'sexo' => $usuario->getSexo(),
                'email_usuario' => $usuario->getEmail(),
                'senha_usuario' => $usuario->getSenha(),
                'telefone_usuario' => $usuario->getTelefone(),
                'perfil' => $usuario->getPerfil()
            ];

            // Insere o documento na coleção
            $result = $collection->insertOne($document);

            // Retorna uma mensagem de sucesso
            return "Usuário cadastrado com sucesso! ID: " . $result->getInsertedId();
        } catch (Exception $e) {
            echo $e->getCode();
            echo $e->getMessage();
            die();
        }
    }

    // Método para fazer o login do usuário
    public function login($usuario){
        try {
            // Seleciona a coleção 'usuarios'
            $collection = $this->db->Usuarios;

            // Consulta o usuário pelo email
            $user = $collection->findOne(['email_usuario' => $usuario->getEmail()]);

            if ($user) {
                return $user;
            } else {
                return null; // Caso o usuário não seja encontrado
            }
        } catch (Exception $e) {
            echo $e->getMessage();
            echo $e->getCode();
            die();
        }
    }
}
?>