variable "location" {
  default = "westeurope"
}

variable "prefix" {
  default = "tfewc"
}

variable "adminusername"{
  default = "adminuser"
}

variable setupelasticfile{
  type=string
  default = "yum.bash"
}