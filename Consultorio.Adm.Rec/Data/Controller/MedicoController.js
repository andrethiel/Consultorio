import { ListarMedico } from "@/Api/MedicoApi";

const resposta = {
  dados: [],
  errors: [],
  sucesso: true,
  message: "",
};

export async function Listar() {
  const response = await ListarMedico().catch(function (error) {
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
