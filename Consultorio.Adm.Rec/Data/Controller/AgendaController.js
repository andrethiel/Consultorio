import { VerificaAgenda } from "@/Api/AgendaApi";
import ErrorAxios from "./ErrorsController";

const resposta = {
  dados: [],
  errors: [],
  sucesso: true,
  message: "",
};

export async function BuscarAgenda(data) {
  const response = await VerificaAgenda(data).catch(function (error) {
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
