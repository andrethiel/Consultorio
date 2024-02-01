import { Get, Post } from "./Api";

const paramets = {
  numeroAtendimento: "",
  medicoId: 0,
  dataConsulta: "",
  pacienteId: 0,
};

export function Inserir(atendimento, medico, data, paciente) {
  (paramets.numeroAtendimento = atendimento),
    (paramets.medicoId = parseInt(medico)),
    (paramets.dataConsulta = data),
    (paramets.pacienteId = parseInt(paciente));
  const response = Post("/Consulta/Inserir", paramets, null);

  return response;
}
