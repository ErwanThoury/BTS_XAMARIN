<?php 
include 'cnx.php';
$sql = "select libelleCategorie as libelle from Categorie";
$sth = $cnx->prepare($sql);
$sth->execute();

 

 
echo json_encode($sth->fetchAll(PDO::FETCH_ASSOC));
 
?>


