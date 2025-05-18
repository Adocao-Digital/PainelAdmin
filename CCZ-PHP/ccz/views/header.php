<?php
	if(!isset($_SESSION))
		session_start();
 ?>
<header>
    <div class="head2">
    </div>
</header>

<nav class="navbar navbar-expand-xl bg-body-tertiary">
  <div class="container-fluid">
    <nav class="navbar bg-body-tertiary">
      <div class="container-fluid">
        <a class="navbar-brand" href="/ccz/">
          <img alt="Logo" class="d-inline-block align-text-top">
        </a>
      </div>
    </nav>
    <button class="navbar-toggler" type="button" data-bs-toggle="collapse" data-bs-target="#navbarSupportedContent" aria-controls="navbarSupportedContent" aria-expanded="false" aria-label="Toggle navigation">
      <span class="navbar-toggler-icon"></span>
    </button>
    <div class="collapse navbar-collapse" id="navbarSupportedContent">
      <ul class="navbar-nav me-auto mb-2 mb-lg-0">
        <li class="nav-item">
          <a class="nav-link" aria-current="page" href="/ccz/">Home</a>
        </li>
        <li class="nav-item">
          <a class="nav-link" href="/ccz/sobre">Sobre nós</a>
        </li>
        <li class="nav-item">
          <a class="nav-link" href="/ccz/fale">Fale conosco</a>
        </li>
        <?php
        if(isset($_SESSION['email']) && $_SESSION['perfil'] == 'Funcionario'){
          echo "<li class='nav-item'>
                  <a class='nav-link' href='/ccz/dashboard'>Painel de Controle</a>
                </li>";
        }
        ?>
      </ul>
      <div class="container c-button">
        <a type="button" href="/ccz/adotar" class="btn btn-success max-width">Quero adotar</a>
        <a type="button" href="/ccz/ajudar" class="btn btn-success max-width">Ajudar</a>
        <?php
        if(isset($_SESSION['email'])){
          echo "<a type='button' href='/ccz/logout' class='btn btn-success max-width'>Sair</a>";
         }else{
          echo "<a type='button' href='/ccz/login' class='btn btn-success max-width'>Entrar</a>";
        }
        ?>
      </div>
    </div>
  </div>
</nav>