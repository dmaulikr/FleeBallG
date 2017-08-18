<?php

$conecta = mysqli_connect( "localhost" , "root", "") or print (mysqli_error() );
mysqli_select_db ( $conecta , "BDFleeBall") or print (mysqli_error());

?>