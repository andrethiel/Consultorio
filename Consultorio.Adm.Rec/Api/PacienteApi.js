import { Get, Post } from "./Api";

export async function CadastroPaciente(
  nome,
  data,
  sexo,
  cpf,
  mae,
  endereco,
  telefone
) {
  const paramets = {
    nomePaciente: "",
    dataNacimento: "",
    sexo: "",
    cpf: "",
    nomeMae: "",
    endereco: "",
    telefone: "",
  };
  paramets.NomePaciente = nome;
  paramets.dataNacimento = data;
  (paramets.sexo = sexo),
    (paramets.cpf = cpf),
    (paramets.nomeMae = mae),
    (paramets.endereco = endereco),
    (paramets.telefone = telefone);
  const response = await Post("/Paciente/Cadastro", paramets, null);

  return response;
}

export async function ListarPacientes() {
  const response = await Get("/Paciente/Listar", null);

  return response;
}

export async function BuscarPacientes(guid) {
  const response = await Get(`/Paciente/Buscar?guid=${guid}`, null);

  return response;
}
