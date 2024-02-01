import { Get } from "./Api";

export function VerificaAgenda(data) {
  const response = Get(`/Agenda?data=${data}`);

  return response;
}
