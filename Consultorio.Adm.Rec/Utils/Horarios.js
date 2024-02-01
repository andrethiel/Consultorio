import "moment/locale/pt-br";
import moment from "moment";
import { HorariosVerifica } from "@/Data/Controller/HorariosController";

export function Horarios(inicial, final, intervalo) {
  let horario = [];
  const star = moment(inicial, "hh:mm").locale("pt-br");
  const end = moment(final, "hh:mm").locale("pt-br");
  for (
    var t = moment(star);
    t.isBefore(end);
    t.add(intervalo, intervalo >= 60 ? "hour" : "minute")
  ) {
    horario.push(t.format("LT"));
  }

  return horario;
}
