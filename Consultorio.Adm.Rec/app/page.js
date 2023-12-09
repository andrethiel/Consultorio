"use client";
import moment from "moment";
import Data from "./Components/Date";
import Tabela from "./Components/Tabela";
import { useState } from "react";

export default function Home() {
  const [hoje, setHoje] = useState(new Date());

  function DataMais() {
    var outraData = new Date();
    outraData.setDate(hoje.getDate() + 1);
    setHoje(outraData);
  }
  function DataMenos() {
    var outraData = new Date();
    outraData.setDate(hoje.getDate() - 1);
    setHoje(outraData);
  }

  const paciente = [
    {
      Id: 1,
      Medico: "Medico 1",
      AtendimentoInicio: "09:00",
      AtendimentoFinal: "15:00",
      Intervalo: 30,
      DataConsulta: "08/12/2023",
      Pacientes: [
        {
          Id: 1,
          Paciente: "paciente paciente paciente 1",
          Horario: "09:00",
        },
      ],
    },
    {
      Id: 2,
      Medico: "Medico 3",
      AtendimentoInicio: "09:00",
      AtendimentoFinal: "18:00",
      Intervalo: 10,
      DataConsulta: "09/12/2023",
      Pacientes: [
        {
          Id: 2,
          Paciente: "paciente paciente paciente 1",
          Horario: "09:10",
        },
      ],
    },
  ];

  return (
    <div className="flex flex-col gap-10">
      <Data
        hoje={moment(hoje).format("DD/MM/YYYY")}
        DataMais={DataMais}
        DataMenos={DataMenos}
      />
      <div className="flex gap-10">
        <div className="flex ">
          {paciente.map((item) =>
            item.DataConsulta == moment(hoje).format("DD/MM/YYYY") ? (
              <Tabela data={item} />
            ) : null
          )}
        </div>
      </div>
    </div>
  );
}

// {
//   Medico: "Medico 3",
//   Paciente: "paciente 1",
//   Horario: "11:00",
// },
