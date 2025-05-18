<?php
    if(isset($_SESSION['nome']))
    {
        header("Location: /ccz/");
    }
?>
<!DOCTYPE html>
<html lang="pt-br">
<head>
    <meta charset="UTF-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Login</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet">
    <link href="https://fonts.googleapis.com/css2?family=Mulish:wght@400;700&display=swap" rel="stylesheet">
    <link rel="stylesheet" href="css/style-footer.css">
    <link rel="stylesheet" href="css/style-header.css">
    <link rel="stylesheet" href="css/style.login.css">
</head>
<body>
    <!-- Início do cabeçalho -->
    <?php
        require_once 'header.php';
    ?>
    <!-- Fim do cabeçalho -->
    <main>
        <div class="conteudo-login">
            <div class="login">
                <h1>Fazer Login</h1>
                <form class="formulario" action="/ccz/login" method="POST">
                    <?php
                        if($mensagem != "")
                        {
                            echo "<div class='alert alert-danger' role='alert'>
                                    $mensagem
                                </div>";
                
                        }
                    ?>
                    <div class="controle">
                        <label for="email"><img class="img-person" src="img/usuario.png" alt="Ícone de usuário"></label>
                        <input class="bx" type="text" name="email" id="email" placeholder="Digite seu e-mail...">
                    </div>
                    <div style="color:red;font-size:10px;"><?php echo $msg[0];?></div>
                    <div class="controle">
                        <label for="senha"><img class="img-lock" src="img/senha.png" alt="Ícone de senha"></label>
                        <input class="bx" type="password" name="senha" id="senha" placeholder="Digite sua senha...">
                        <button type="button" class="mostrar-senha" onclick="toggleSenha()">
                            <img src="img/closed-eye.png" alt="Mostrar/Esconder senha" id="imgSenha">
                        </button>
                    </div>
                    <div style="color:red;font-size:10px;"><?php echo $msg[1];?></div>
                    <input class="controle-login bxlogin" type="submit" value="Login">
                </form>
                <a href="#" class="parag">Esqueci minha senha</a>
                <a href="/ccz/cadastro" class="registro-link">Registrar</a>
            </div>
        </div>
    </main>
    <footer>
        <?php
            require_once 'footer.html';
        ?>
    </footer>
    <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.11.8/dist/umd/popper.min.js" integrity="sha384-I7E8VVD/ismYTF4hNIPjVp/Zjvgyol6VFvRkX/vR+Vc4jQkC+hVqc2pM8ODewa9r" crossorigin="anonymous"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.min.js" integrity="sha384-0pUGZvbkm6XF6gxjEnlmuGrJXVbNuzT9qBBavbLwCsOGabYfZo0T0to5eqruptLy" crossorigin="anonymous"></script>
    <script src="js/script.js"></script>
</body>
</html>
