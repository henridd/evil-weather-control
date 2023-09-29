output "function_app_name" {
  value = azurerm_linux_function_app.function.name
  description = "Deployed function app name"
}

output "function_app_default_hostname" {
  value = azurerm_linux_function_app.function.default_hostname
  description = "Deployed function app hostname"
}

output "public_ip_address" {
  value = azurerm_linux_virtual_machine.elasticvm.public_ip_address
}