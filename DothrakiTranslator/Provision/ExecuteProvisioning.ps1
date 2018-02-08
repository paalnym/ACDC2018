param 
(     
	[string]$url = "URL", 
	[string]$user = "USERNAME", #Username with domain
	[string]$password = "PASSWORD " #Password for user
	
)

#Set-Location $exepathcmd
Start-Process -FilePath .\bin\Debug\Provision.exe -ArgumentList "$url $user $password";
