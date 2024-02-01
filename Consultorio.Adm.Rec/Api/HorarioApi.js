import { Get } from "./Api";

export function VerificarHorario(medico, data) {
  const response = Get(`/Horarios?medico=${medico}&data=${data}`, null);

  return response;
}
