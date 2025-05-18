<?php
	class Rotas
	{
		public array $rotas = [];
		
		public function get(string $nome_rota, array $dados)
		{
			$this->rotas["GET"][$nome_rota] = $dados;
		}
		
		public function post(string $nome_rota, array $dados)
		{
			$this->rotas["POST"][$nome_rota] = $dados;
		}
		
		public function verificar_rota($metodo, $nome_rota)
		{
			if(isset($this->rotas[$metodo][$nome_rota]))
			{
				$dados = $this->rotas[$metodo][$nome_rota];
				$method = $dados[1];
				$obj = new $dados[0]();
				return $obj->$method();
			}
			exit("Rota é inválida");
		}
	}//fim da classe
	//instanciar um objeto classe Rotas
	$route = new Rotas();
	$route->get("/",[InicioController::class,"inicio"]);
	$route->get("/adotar",[AdotarController::class,"tela"]);
	$route->get("/sobre",[SobreController::class,"tela"]);
	$route->get("/fale",[FaleController::class,"tela"]);
	$route->get("/ajudar",[AjudarController::class,"tela"]);
	$route->get("/cadastro-pet",[CadastropetController::class,"cadastropet"]);
    $route->get("/cadastro", [UsuarioController::class, "cadastro"]);
    $route->post("/cadastro", [UsuarioController::class, "cadastro"]);
    $route->get("/login", [UsuarioController::class, "login"]);
    $route->post("/login", [UsuarioController::class, "login"]);
    $route->get("/logout", [UsuarioController::class, "logout"]);
	$route->get("/dashboard", [DashboardController::class, "tela"]);
	$route->get("/dashboard/publicacao", [PublicacaoController::class, "tela"]);
?>