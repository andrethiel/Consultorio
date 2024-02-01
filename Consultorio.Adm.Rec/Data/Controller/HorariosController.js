import { VerificarHorario } from "@/Api/HorarioApi";
import ErrorAxios from "./ErrorsController";

const resposta = {
  dados: [],
  errors: [],
  sucesso: true,
  message: "",
};

export async function HorariosVerifica(medico, date) {
  resposta.dados = [];
  resposta.errors = [];
  resposta.sucesso = true;
  resposta.message = "";
  const response = await VerificarHorario(medico, date, null).catch(function (
    error
  ) {
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
