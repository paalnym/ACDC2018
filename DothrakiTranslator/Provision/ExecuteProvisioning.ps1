param 
(     
	[string]$path = "Path",
	[string]$adminTenantUrl = "Admin tenant url",
	[string]$url = "New Site Collection Url", 
	[string]$user = "User name", 
	[string]$password = "Password" 
	
)

Set-Location $path
Start-Process -FilePath .\Provision.exe -ArgumentList "$adminTenantUrl $url $user $password";
