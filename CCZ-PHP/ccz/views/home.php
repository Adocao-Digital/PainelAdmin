<!DOCTYPE html>
<html lang="pt-br">

<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Centro de Controle de Zoonoses</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet">
    <link rel="stylesheet" href="css/style-index.css">
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

    <main>
        <!-- Carousel com Indicadores -->
        <div id="carouselExampleIndicators" class="carousel slide mx-auto mt-4" data-bs-ride="carousel">
            <div class="carousel-indicators">
                <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="0" class="active" aria-current="true" aria-label="Slide 1"></button>
                <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="1" aria-label="Slide 2"></button>
                <button type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide-to="2" aria-label="Slide 3"></button>
            </div>
            <div class="carousel-inner">
                <div class="carousel-item active">
                    <img src="img/animal1.avif" class="d-block carousel-image" alt="Primeira imagem">
                </div>
                <div class="carousel-item">
                    <img src="img/animal2.webp" class="d-block carousel-image" alt="Segunda imagem">
                </div>
                <div class="carousel-item">
                    <img src="img/animais5.avif" class="d-block carousel-image" alt="Terceira imagem">
                </div>
            </div>
            <button class="carousel-control-prev" type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide="prev">
                <span class="carousel-control-prev-icon" aria-hidden="true"></span>
                <span class="visually-hidden">Previous</span>
            </button>
            <button class="carousel-control-next" type="button" data-bs-target="#carouselExampleIndicators" data-bs-slide="next">
                <span class="carousel-control-next-icon" aria-hidden="true"></span>
                <span class="visually-hidden">Next</span>
            </button>
        </div>
<div class="d-flex flex-wrap justify-content-center gap-4 mt-5">
    <div class="card">
        <a href="/ccz/adotar">
            <img src="img/pets.png" alt="Imagem pets">
        </a>
        <div>
            <a href="/ccz/adotar" class="stretched-link">
                <p>Encontre seu melhor amigo</p>
            </a>
        </div>
    </div>
    <div class="card">
        <a href="/ccz/cadastro-pet">
            <img src="img/form.png" alt="Imagem formulário">
        </a>
        <div>
            <a href="/ccz/cadastro-pet" class="stretched-link">
                <p>Registre seu pet</p>
            </a>
        </div>
    </div>
    <?php
    if(!isset($_SESSION['nome'])){
    echo "<div class='card'>
        <a href='/ccz/cadastro'>
            <img src='img/registrese.png' alt='Imagem cadastro'>
        </a>
        <div>
            <a href='/ccz/cadastro' class='stretched-link'>
                <p>Faça seu cadastro</p>
            </a>
        </div>
    </div>";
    }
    ?>
    <div class="card">
        <a href="https://barrabonita.sp.gov.br" target="_blank">
            <img src="img/prefeitura.png" alt="Imagem prefeitura">
        </a>
        <div>
            <a href="https://barrabonita.sp.gov.br" target="_blank" class="stretched-link">
                <p>Site da prefeitura</p>
            </a>
        </div>
    </div>
</div>

    </main>

    <script src="js/script-ativo.js"></script>
    <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.0/dist/js/bootstrap.bundle.min.js"></script>
</body>

<footer>
    <?php
        require_once 'footer.html';
    ?>
</footer>
</html>
