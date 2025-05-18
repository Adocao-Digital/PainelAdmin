<?php
class AdotarController
{
    public function tela()
    {
        $petAdocaoDAO = new PetadocaoDAO();
        $retorno = $petAdocaoDAO->listarPetadocao();
        require_once "views/quero-adotar.php";
    }
}
?>