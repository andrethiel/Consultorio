"use client";

import React, { useEffect, useState } from "react";
import Link from "next/link";
import { Horarios } from "@/Utils/Horarios";

function Tabela({ data }) {
  const [tempo, settempo] = useState([]);

  useEffect(() => {
    settempo(
      Horarios(
        data.medico.atendimentoInicio,
        data.medico.atendimentoFinal,
        data.medico.intervalo
      )
    );
  }, []);

  function Row(horario) {
    return (
      <tr>
        <td className="border px-4 py-2">{horario}</td>
        {data.pacientes.map((pac) =>
          pac.horario == horario ? (
            <td className="border px-4 py-2">{pac.nomePaciente}</td>
          ) : null
        )}
      </tr>
    );
  }

  return (
    <div>
      {tempo.length > 0 ? (
        <table className="table-fixed text-sm">
          <thead className="border uppercase">
            <tr>
              <th className="px-4 py-2">Horario</th>
              <th className=" px-4 py-2">{data.medico.nomeMedico}</th>
            </tr>
          </thead>
          <tbody>{tempo.map((item) => Row(item))}</tbody>
        </table>
      ) : (
        "Carregando"
      )}
    </div>
  );
}

export default Tabela;
