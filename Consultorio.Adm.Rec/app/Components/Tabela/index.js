"use client";
import moment from "moment";
import React, { useEffect, useState } from "react";
import "moment/locale/pt-br";
import Link from "next/link";

function Tabela({ data }) {
  const horario = [];

  const [tempo, settempo] = useState([]);

  useEffect(() => {
    function horarios() {
      const star = moment(data.AtendimentoInicio, "hh:mm").locale("pt-br");
      const end = moment(data.AtendimentoFinal, "hh:mm").locale("pt-br");
      for (
        var t = moment(star);
        t.isBefore(end);
        t.add(data.Intervalo, data.Intervalo >= 60 ? "hour" : "minute")
      ) {
        horario.push(t.format("LT"));
      }
      settempo(horario);
    }
    horarios();
  }, []);

  return (
    <div>
      {tempo.length > 0 ? (
        <table className="table-fixed text-sm">
          <thead className="border uppercase">
            <tr>
              <th className="px-4 py-2">Horario</th>
              <th className=" px-4 py-2">{data.Medico}</th>
            </tr>
          </thead>
          <tbody>
            {tempo.map((item) => (
              <tr>
                <th className="border px-4 py-2">{item}</th>
                {data.Pacientes.map((pac) =>
                  pac.Horario == item ? (
                    <th className="border px-4 py-2">{pac.Paciente}</th>
                  ) : (
                    <th className="border px-4 py-2 cursor-pointer">
                      <Link
                        href={`/Agenda?horario=${item}&data=${data.DataConsulta}&medico=${data.Id}`}
                      >
                        Horario livre
                      </Link>
                    </th>
                  )
                )}
              </tr>
            ))}
          </tbody>
        </table>
      ) : (
        "Carregando"
      )}
    </div>
  );
}

export default Tabela;
