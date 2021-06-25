<?php
include 'funcs.php';
$db = new Functions();
if(isset($_GET["name"]) && isset($_GET["surname"]) && isset($_GET["login"]) && isset($_GET["email"]) && isset($_GET["password"])&& isset($_GET["reg_ip"]))
{
    $name = $_GET["name"];
    $surname = $_GET["surname"];
    $login = $_GET["login"];
    $email = $_GET["email"];
    $password = $_GET["password"];
    $reg_ip = $_GET["reg_ip"];
    $user = $db->regUser($name, $surname,$login, $email, $password, $reg_ip);
    return 'Yes';
}
 else echo 'Missing parameters';
?>