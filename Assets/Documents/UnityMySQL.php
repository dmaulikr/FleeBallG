<?php
include ("conexao.php");

if($_POST["action"] == "login")
{
	$email = $_POST['Email'];
	$senha = $_POST['senha'];
	
	$queryUnico = "SELECT `user_email` , `user_pass` FROM `BDFleeBall` WHERE `user_email` = '$email'"; 
	$resultado = mysqli_query($conecta , $queryUnico)or die ('Falhou ' . mysqli_error());
	$quantidadeResult = mysqli_num_rows($resultado);
	
	if($quantidadeResult == 0){
		echo 'The user is not registered';
	}else{
		$linha = mysqli_fetch_array($resultado);
		if($linha['user_pass'] == $senha)
		{
			echo 'LOGGED';
		}else{
			echo 'Incorrect password. Please try again';
		}
	}
}
if($_POST["action"] == "register")
{
	$email = $_POST['Email'];
	$nickName = $_POST['nickName'];
	$senha = $_POST['senha'];
	
	$queryUnico = "SELECT `user_email` FROM `BDFleeBall` WHERE `user_email` = '$email'"; 
	$resultado = mysqli_query($conecta , $queryUnico)or die ('Falhou ' . mysqli_error());
	$quantidadeResult = mysqli_num_rows($resultado);
	
	if($quantidadeResult == 0){
		$query = "INSERT INTO `BDFleeBall` (`user_email` ,`user_nickname`, `user_pass`) VALUES ('$email' , '$nickName' , '$senha')";
		mysqli_query($conecta , $query)or die ('Falhou ' . mysqli_error());
		echo 'User successfully registered';
	}else{
		echo 'User already registered';
	}
}
if($_POST["action"] == "BestScore")
{
	$email = $_POST['email'];
	$senha = $_POST['senha'];
	$pontosResultado = $_POST['bestscorePlayer'];
	
	$queryUnico = "SELECT `user_email`, `user_pass`, `user_bestscore` FROM `BDFleeBall` WHERE `user_email` = '$email' AND `user_pass` = '$senha'"; 
	$resultado = mysqli_query($conecta , $queryUnico)or die ('Falhou ' . mysqli_error());
	$linha = mysqli_fetch_array($resultado);
	$queryAtualizaPontos = "UPDATE `BDFleeBall` SET `user_bestscore` = '$pontosResultado' WHERE `user_bestscore` <= '$pontosResultado' && `user_email` = '$email' && `user_pass` = '$senha'";
	$resultadoP = mysqli_query($conecta, $queryAtualizaPontos) or die ('Falhou' . mysqli_error());
}
if($_POST["action"] == "PegaStats")
{
	$nickName = $_POST['nickName'];
	$senha = $_POST['senha'];
	
	$queryUnico = "SELECT `user_nickname`, `user_pass`, `user_bestscore` FROM `BDFleeBall` WHERE `user_nickname` = '$nickName' AND `user_pass` = '$senha'"; 
	$resultado = mysqli_query($conecta , $queryUnico)or die ('Falhou ' . mysqli_error());
	$linha = mysqli_fetch_array($resultado);
	
	echo ' ' .$linha['user_bestscore'];

}
if($_POST["action"] == "pegaRank")
{
		
	$queryPegaRank = "SELECT user_nickname, user_bestscore FROM BDFleeBall ORDER BY user_bestscore DESC LIMIT 50"; 
	$resultado = mysqli_query($conecta , $queryPegaRank)or die ('Falhou ' . mysqli_error());
	
	while($linha = mysqli_fetch_array($resultado))
	{
		echo $linha['user_nickname'] . " - ";
		echo $linha['user_bestscore'] . "|";
	}

}



?>
