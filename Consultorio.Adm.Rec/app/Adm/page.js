"use client";
import moment from "moment";
import Data from "../Components/Date";
import Tabela from "../Components/Tabela";
import { useEffect, useState } from "react";
import { BuscarAgenda } from "@/Data/Controller/AgendaController";

export default function Home() {
  const [hoje, setHoje] = useState(new Date());
  const [pacientes, setPacientes] = useState([]);
  const [errors, setErros] = useState([]);
  const [typeAlert, settypeAlert] = useState("");

  useEffect(() => {
    Agenda();
  }, []);

  async function Agenda(data) {
    const response = await BuscarAgenda(data);
    if (response.sucesso) {
      setPacientse(response.dados[0].dados);
    } else {
      if (response.errors.length > 1) {
        setErros(response.errors);
      } else {
        setErros([response.message]);
      }
    }
  }

  function DataMais() {
    setPacientse([]);
    var outraData = new Date();
    outraData.setDate(hoje.getDate() + 1);
    setHoje(outraData);
    Agenda(moment(outraData).format("DD/MM/YYYY"));
  }
  function DataMenos() {
    var outraData = new Date();
    outraData.setDate(hoje.getDate() - 1);
    setHoje(outraData);
  }

  return (
    <div className="flex flex-col gap-10">
      <Data
        hoje={moment(hoje).format("DD/MM/YYYY")}
        DataMais={DataMais}
        DataMenos={DataMenos}
      />
      <div className="flex gap-10">
        <div className="flex ">
          {pacientes.length > 0 &&
            pacientes.map((item) =>
              item.dataConsulta == moment(hoje).format("DD/MM/YYYY") ? (
                <Tabela data={item} />
              ) : (
                "Sem agendamentos"
              )
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
