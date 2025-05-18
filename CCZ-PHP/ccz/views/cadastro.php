<?php
    if(isset($_SESSION['nome']))
    {
        header("Location: /ccz/");
    }
?>
<!DOCTYPE html>
<html lang="pt-br">

<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Faça seu cadastro</title>
    
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous">
    <link rel="stylesheet" href="css/style_cadastro.css">
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
            <form action="/ccz/cadastro" method="post">
                <div class="form">
                    <h1>Registrar-se</h1>
                    <label for="nome" class="padding">Nome:
                        <input type="text" id="nome" name="nome" class="estilo-forms" placeholder="Digite seu nome..." required>
                    </label>
                    <label for="nome" class="padding">Sobrenome:
                        <input type="text" id="sobrenome" name="sobrenome" class="estilo-forms" placeholder="Digite seu sobrenome..." required>
                    </label>
                    <label for="cpf">CPF:
                        <input type="text" id="cpf" name="cpf" class="estilo-forms" placeholder="Digite seu CPF..." required>
                    </label>
                    <label for="email">E-mail:
                        <input type="text" id="email" name ="email" class="estilo-forms" placeholder="Digite seu e-mail..." required>
                    </label>
                    <label for="senha">Digite sua senha:
                        <input type="password" name="senha" id="senha" class="estilo-forms" placeholder="Digite sua senha..." required>
                    </label>
                    <label for="confirma">Confirme sua senha:
                        <input type="password" id="confirma" name="confirma" class="estilo-forms" placeholder="Confirme sua senha..." required>
                        <span id="escrita" class="error"></span>
                    </label>
                    <label for="telefone">Telefone:
                        <input type="text" id="telefone" name="telefone" class="estilo-forms" pattern="\d{10,11}" placeholder="Digite seu telefone..." required>
                    </label>
                    <label for="sexo">Sexo:
                        <select name="sexo" required class="sexoform">
                            <option value="" disabled selected>Selecione...</option>
                            <option value="Masculino">Masculino</option>
                            <option value="Feminino">Feminino</option>
                            <option value="Não-binário">Não-binário</option>
                            <option value="NULL">Prefiro não informar</option>
                        </select>
                    </label>
                    <label for="datanasc">Selecione sua data de nascimento:<br>
                        <input type="date" name="datanasc" id="datanasc" class="estilo-forms" required>
                    </label> 
                    <div class="cad">
                        <button type="submit">Cadastrar</button>
                    </div>
                </div>
            </form>
        </div>
        <div class="caixa-esquerda">
            <div class="titulo-cadastro">
                <h1>Já se registrou?</h1>
            </div>
            <h2>Seja bem-vindo de volta! <br /> Venha fazer a diferença <br />conosco.</h2>
            <div class="botao-entrar">
                <a href="/ccz/login">Entrar</a>
            </div>
        </div>
    </div>

    <script src="js/script-ativo.js"></script>
    <script src="js/script-cad.js"></script>
</body>
<footer>
    <?php
        require_once 'footer.html';
    ?>
</footer>
<script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.11.8/dist/umd/popper.min.js" integrity="sha384-I7E8VVD/ismYTF4hNIPjVp/Zjvgyol6VFvRkX/vR+Vc4jQkC+hVqc2pM8ODewa9r" crossorigin="anonymous"></script>
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.min.js" integrity="sha384-0pUGZvbkm6XF6gxjEnlmuGrJXVbNuzT9qBBavbLwCsOGabYfZo0T0to5eqruptLy" crossorigin="anonymous"></script>
</html>