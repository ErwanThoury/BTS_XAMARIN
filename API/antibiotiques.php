<?php 
include 'cnx.php';

$sql = "
SELECT libelleATB, uniteATB, nbParJour, doseKilo, dosePrise, type, libelleCategorie 
FROM Antibio a INNER JOIN Categorie c
    ON a.numCateg = c.idCategorie
";
$sth = $cnx->prepare($sql);
$sth->execute();

$json = [];
 while($row = $sth->fetch()){
     if($row["type"] == "kg"){
        $json[] = [
            "\$type"=> "ProjetAntiBIO.AntibioParKilo, ProjetAntiBIO",
            "doseKilo"=>intval($row["doseKilo"]),
            "libelle"=>$row["libelleATB"],
            "unite"=>$row["uniteATB"],
            "laCategorie"=>[
                "libelle"=>$row["libelleCategorie"]
            ],
            "nombreParJour"=>intval($row["nbParJour"])
        ];
     }else{
        $json[] = [
            "\$type"=> "ProjetAntiBIO.AntibioParPrise, ProjetAntiBIO",
            "dosePrise"=>intval($row["dosePrise"]),
            "libelle"=>$row["libelleATB"],
            "unite"=>$row["uniteATB"],
            "laCategorie"=>[
                "libelle"=>$row["libelleCategorie"]
            ],
            "nombreParJour"=>intval($row["nbParJour"])
        ];
     }
   
 }

 
echo json_encode($json);
 
?>


