import { NumeroAtendimento } from "@/Api/AtendimentoApi";
import ErrorAxios from "./ErrorsController";

const resposta = {
  dados: [],
  errors: [],
  sucesso: true,
  message: "",
};

export async function Atendimento() {
  const response = await NumeroAtendimento().catch(function (error) {
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
