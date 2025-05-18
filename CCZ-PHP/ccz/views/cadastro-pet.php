<?php
session_start();

// Verifica se o usuário está autenticado
if (!isset($_SESSION['nome'])) {
    // Salva a URL da página atual na sessão
    $_SESSION['redirect_to'] = $_SERVER['REQUEST_URI'];
    // Redireciona para a página de login
    header("Location: /ccz/login");
    exit;
}
?>
<!DOCTYPE html>
<html lang="pt-br">

<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Cadastre seu pet</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous">
    <link rel="stylesheet" href="css/style-pet-1.css">
    <link rel="stylesheet" href="css/style-footer.css">
    <link rel="stylesheet" href="css/style-header.css">
    <link rel="icon" type="image/x-icon" href="img/dogo-argentino.png">
    <link rel="preconnect" href="https://fonts.googleapis.com">
    <link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
    <link href="https://fonts.googleapis.com/css2?family=Mulish:ital,wght@0,200..1000;1,200..1000&display=swap" rel="stylesheet">
</head>

<body>
    <!-- Início do cabeçalho -->
    <?php
        require_once 'header.php';
    ?>
    <!-- Fim do cabeçalho -->
   
    <div class="caixa-total">
        <div class="caixa-direita">
            <form>
                <h1>Registre seu Pet!</h1>
                <label for="inome" class="padding">Nome do pet:</label>
                <input type="text" id="itext" class="estilo-forms" placeholder="Digite o nome do seu pet..." required>
                <label for="iemail">Idade:</label>
                <input type="text" id="iemail" class="estilo-forms" placeholder="Digite a idade do seu pet..." required>
                <label for="ipassword">Sexo:</label>
                <select name="select" required>
                    <option value="valor1">Selecione...</option>
                    <option value="valor2">Macho</option>
                    <option value="valor3">Fêmea</option>
                </select>
                <label for="iconfirm">Peso:</label>
                <input type="password" id="iconfirm" class="estilo-forms" placeholder="Digite o peso atual do seu pet..." required>
                <div class="cad">
                    <button class="submit-button" type="submit">Cadastrar</button>
                </div>
            </form>
        </div>
    </div>
    <script src="js/script-ativo.js"></script>
</body>

<footer>
    <?php
        require_once 'footer.html';
    ?>
</footer>
<script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.11.8/dist/umd/popper.min.js" integrity="sha384-I7E8VVD/ismYTF4hNIPjVp/Zjvgyol6VFvRkX/vR+Vc4jQkC+hVqc2pM8ODewa9r" crossorigin="anonymous"></script>
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.min.js" integrity="sha384-0pUGZvbkm6XF6gxjEnlmuGrJXVbNuzT9qBBavbLwCsOGabYfZo0T0to5eqruptLy" crossorigin="anonymous"></script>
<script src="js/form.js" defer></script>
</html>
