import {
  BuscarPacientes,
  CadastroPaciente,
  ListarPacientes,
} from "@/Api/PacienteApi";
import ErrorAxios from "@/Data/Controller/ErrorsController";

const resposta = {
  dados: [],
  errors: [],
  sucesso: true,
  message: "",
};

export async function Cadastro(nome, data, sexo, cpf, mae, endereco, telefone) {
  const response = await CadastroPaciente(
    nome,
    data,
    sexo,
    cpf,
    mae,
    endereco,
    telefone
  ).catch(function (error) {
    resposta.errors = ErrorAxios(error);
    resposta.sucesso = false;
  });

  if (resposta.sucesso) {
    resposta.dados.push(response.data);
    resposta.sucesso = true;
    resposta.message = response.data.message;

    return resposta;
  } else {
    return resposta;
  }
}

export async function PacienteListar() {
  const response = await ListarPacientes().catch(function (error) {
    resposta.errors = ErrorAxios(error);
    resposta.sucesso = false;
  });

  if (resposta.sucesso) {
    resposta.dados = response.data;
    resposta.sucesso = true;
    resposta.message = response.data.message;

    return resposta;
  } else {
    return resposta;
  }
}

export async function BuscarPaciente(guid) {
  const response = await BuscarPacientes(guid).catch(function (error) {
    resposta.errors = ErrorAxios(error);
    resposta.sucesso = false;
  });

  if (resposta.sucesso) {
    resposta.dados = response.data;
    resposta.sucesso = true;
    resposta.message = response.data.message;

    return resposta;
  } else {
    return resposta;
  }
}
