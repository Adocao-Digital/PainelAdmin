<!DOCTYPE html>
<html lang="pt-br">
<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Centro de Controle de Zoonoses</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous">
    <link rel="stylesheet" href="css/style-footer.css">
    <link rel="stylesheet" href="css/style-header.css">
    <link rel="stylesheet" href="css/style-fale.css">
    <link rel="icon" type="image/x-icon" href="img/dogo-argentino.png">
    <link rel="preconnect" href="https://fonts.googleapis.com">
<link rel="preconnect" href="https://fonts.gstatic.com" crossorigin>
<link href="https://fonts.googleapis.com/css2?family=Mulish:ital,wght@0,200..1000;1,200..1000&display=swap" rel="stylesheet">
</head>
<body>
    <!-- Início do header -->
    <?php
        require_once 'header.php';
    ?>
    <!-- Fim do header -->
    <div class="container display">
        <div class="card card-fale c-w">
            <div class="card-body text">
                Seja Bem-vindo(a) ao Fale Conosco
            </div>
        </div>
    </div>
    <div class="container c-fale">
        <div class="card img-fale" style="width: 18rem;">
            <img src="./img/duvidas2.png" class="card-img-top" alt="formulario">
            <div class="card-body change">
                <h5 class="card-title">Dúvidas</h5>
                <p class="card-text">Tire suas dúvidas através de um formulário (google forms).</p>
                <a href="#" class="btn btn-success">Clique aqui</a>
            </div>
        </div>
        <div class="card img-fale" style="width: 18rem;">
            <img src="./img/lampada.png" class="card-img-top" alt="formulario">
            <div class="card-body change">
                <h5 class="card-title">Sugestões</h5>
                <p class="card-text">Envie sugestões para o CCZ através de um formulário (google forms).</p>
                <a href="#" class="btn btn-success">Clique aqui</a>
            </div>
        </div>
        <div class="card img-fale" style="width: 18rem;">
            <img src="./img/denuncia.png" class="card-img-top" alt="formulario">
            <div class="card-body change">
                <h5 class="card-title">Denúncias</h5>
                <p class="card-text">Para denunciar alguma ocorrência envie por fomulário (google forms).</p>
                <a href="#" class="btn btn-success">Clique aqui</a>
            </div>
        </div>
    </div>
    <div class="container c-bottom">
        <div class="container display">
            <div class="card card-fale">
                <div class="card-body text">
                    Redes Sociais
                </div>
            </div>
        </div>
        <div class="img-social">
                <a href="#"><img src="./img/instagram.png" class="img-fluid image-fale" alt="instagram"></a>
                <a href="#"><img src="./img/facebook.png" class="img-fluid image-fale" alt="facebook"></a>
        </div>
        <figure class="text-center figure-fale">
            <blockquote class="blockquote">
                <p class="parag-fale">"Olá! Estamos aqui para garantir a saúde e o bem-estar dos animais e da comunidade. Como podemos ajudar hoje?"</p>
            </blockquote>
        </figure>
        <figure class="text-center figure-fale">
            <blockquote class="blockquote">
                <p class="parag-fale">Endereço</p>
            </blockquote>
            <figcaption class="blockquote-footer">
                <address class="add-fale">Endereço: BRB 246 - Jardim Bela Vista (Antigo Sítio Escola) – Município de Barra Bonita
                Telefones: (14)3641-0003 e (14)99662 0512</address>
            </figcaption>
        </figure>
    </div>
</body>
<footer>
    <?php
        require_once 'footer.html';
    ?>
</footer>
<script src="js/script-ativo.js"></script>
<script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.11.8/dist/umd/popper.min.js" integrity="sha384-I7E8VVD/ismYTF4hNIPjVp/Zjvgyol6VFvRkX/vR+Vc4jQkC+hVqc2pM8ODewa9r" crossorigin="anonymous"></script>
<script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.min.js" integrity="sha384-0pUGZvbkm6XF6gxjEnlmuGrJXVbNuzT9qBBavbLwCsOGabYfZo0T0to5eqruptLy" crossorigin="anonymous"></script>
</html>