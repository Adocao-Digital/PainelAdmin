<?php
class ConexaoMongo
{
    public function __construct(protected $db = null)
    {
        $uri = "mongodb://localhost:27017"; // URI do MongoDB
        try {
            // Conectar ao MongoDB
            $client = new MongoDB\Client($uri);
            $this->db = $client->CCZ; // Nome do banco de dados
        } catch (Exception $e) {
            echo $e->getCode();
            echo $e->getMessage();
            die();
        }
    }
}
?>