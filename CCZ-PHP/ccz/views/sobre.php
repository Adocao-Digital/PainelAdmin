<!DOCTYPE html>
<html lang="pt-br">

<head>
    <meta charset="utf-8">
    <meta name="viewport" content="width=device-width, initial-scale=1.0">
    <title>Centro de Controle de Zoonoses</title>
    <link href="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/css/bootstrap.min.css" rel="stylesheet" integrity="sha384-QWTKZyjpPEjISv5WaRU9OFeRpok6YctnYmDr5pNlyT2bRjXh0JMhjY6hW+ALEwIH" crossorigin="anonymous">
    <link rel="stylesheet" href="css/style-sobre.css">
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


     

    <div class="container mt-4">
        <div class="left-mine">
                <div class="cap"><a href="#1">Sobre nós</a></div>
                <div class="cap"><a href="#2">Trabalhos</a></div>
                <div class="cap"><a href="#3">Endereço</a></div>
        </div>

            <!-- Conteúdo principal -->
             
        <div class="principal">
            <section id="1" class="mb-4">
                <h1 class="h">Sobre o CCZ</h1>
                    <div class="foto2 text-center mb-4">
                        <div class="foto-container">
                            <img src="img/canil.jpg" class="foto-canil" alt="Canil">
                        </div>
                    </div>
                    <div class="texto">
                            <p>
                                O Centro de Controle de Zoonoses é um órgão da prefeitura sem fins lucrativos responsável por cuidar do bem-estar dos animais de todo o município. Nós também cuidamos da parte de adoção e divulgação de animais, até mesmo em resgate de animais maltratados que precisam de ajuda. Fazemos uma média mensal de animais castrados, sendo que nossas pesquisas retornaram um número de 80 a 100 animais castrados por mês, com atendimento gratuito e agendamento. Também possuímos uma clínica veterinária e também ajudamos a cuidar dos animais durante a pandemia.
                            </p>
            </section>
                    <section id="2" class="mb-4">
                        <h2>Trabalhos</h2>
                        <p>
                            Trabalhamos principalmente com castração e adoção de animais, assim como controle de pestes na cidade de Barra Bonita. Alguns exemplos da nossa atuação:
                            <ul>
                                <li><strong>7 de maio:</strong> Mutirão de castração para promover o controle populacional e posse responsável de animais de estimação na cidade da Barra Bonita, podendo cadastrar os animais para castração apenas pessoas que comprovem sua baixa renda.</li>
                                <li><strong>2 de fevereiro:</strong> O CCZ anunciou que possui 38 cães, entre adultos e filhotes, prontos para encontrar um novo lar. Esses cães estão disponíveis para adoção após um processo judicial.</li>
                                <li><strong>3 de maio:</strong> Foi iniciado um projeto de conscientização sobre adoção de animais juntamente com uma concessionária de Barra Bonita.</li>
                            </ul>
                        </p>
                    </section>
                    <section id="3" class="mb-4">
                        <h2>Endereço</h2>
                        <p>Centro de Controle de Zoonoses - CCZ<br />
                            BRB-246, Barra Bonita - SP, 17340-000</p>
                        <div class="ratio ratio-16x9">
                            <iframe src="https://www.google.com/maps/embed?pb=!1m18!1m12!1m3!1d3686.388097185679!2d-48.58671692575893!3d-22.489617623093118!2m3!1f0!2f0!3f0!3m2!1i1024!2i768!4f13.1!3m3!1m2!1s0x94c74f4637626c97%3A0xa0f90c286161afd2!2sCentro%20de%20Controle%20de%20Zoonoses%20-%20CCZ!5e0!3m2!1spt-BR!2sbr!4v1718140629567!5m2!1spt-BR!2sbr" allowfullscreen></iframe>
                        </div>
                    </section>
                </div>
            </div>
        </div>

        <script src="https://cdn.jsdelivr.net/npm/@popperjs/core@2.11.8/dist/umd/popper.min.js" integrity="sha384-I7E8VVD/ismYTF4hNIPjVp/Zjvgyol6VFvRkX/vR+Vc4jQkC+hVqc2pM8ODewa9r" crossorigin="anonymous"></script>
        <script src="https://cdn.jsdelivr.net/npm/bootstrap@5.3.3/dist/js/bootstrap.min.js" integrity="sha384-0pUGZvbkm6XF6gxjEnlmuGrJXVbNuzT9qBBavbLwCsOGabYfZo0T0to5eqruptLy" crossorigin="anonymous"></script>
    <script src="js/script-ativo.js"></script>
</body>
<?php
    require_once 'footer.html';
?>

</html>