"use client";
import React, { useEffect, useState } from "react";
import Select from "../../Components/Select";
import AutoComplete from "../../Components/AutoComplete";
import Button from "../../Components/Button";
import Ahref from "../../Components/Link";
import { useRouter, useSearchParams } from "next/navigation";
import { Listar } from "@/Data/Controller/MedicoController";
import {
  BuscarPaciente,
  PacienteListar,
} from "@/Data/Controller/PacienteController";
import SelectDatas from "@/app/Components/DatePicker";
import { Horarios } from "@/Utils/Horarios";
import { HorariosVerifica } from "@/Data/Controller/HorariosController";
import moment from "moment";
import { InserirConsulta } from "@/Data/Controller/ConsultaController";
import Alerta from "@/app/Components/Alerta";
import Input from "@/app/Components/Input";
import { Atendimento } from "@/Data/Controller/AtendimentoController";

function Consulta() {
  const param = useSearchParams();
  const [horario, setHorario] = useState([]);
  const [date, setDate] = useState("");
  const [medico, setMedico] = useState([]);
  const [pacientes, setPacientes] = useState([]);
  const [pacienteId, setPacienteId] = useState("");
  const [medicoId, setMedicoId] = useState("");
  const [numAtendimento, setAtendimento] = useState("");
  const [errors, setErros] = useState([]);
  const [typeAlert, settypeAlert] = useState("");
  const router = useRouter();

  useEffect(() => {
    ListarMedicos();
    Pacientes();
    NumeroAtendimento();
  }, []);

  async function ListarMedicos() {
    const response = await Listar();
    if (response.sucesso) {
      setMedico(response.dados[0].dados);
    } else {
      if (response.errors.length > 1) {
        setErros(response.errors);
      } else {
        setErros([response.message]);
      }
    }
  }

  async function Pacientes() {
    if (param.get("paciente") != null) {
      const response = await BuscarPaciente(param.get("paciente"));
      if (response.sucesso == true) {
        const itens = Array.from(pacientes);
        itens.push({
          value: response.dados.dados.id,
          label: response.dados.dados.nomePaciente,
        });
        setPacientes(itens);
      } else {
        if (response.errors.length > 1) {
          setErros(response.errors);
        } else {
          setErros([response.message]);
        }
      }
    } else {
      const response = await PacienteListar();
      if (response.sucesso == true) {
        const itens = Array.from(pacientes);
        for (var item of response.dados.dados) {
          itens.push({ value: item.id, label: item.nomePaciente });
        }
        setPacientes(itens);
      } else {
        if (response.errors.length > 1) {
          setErros(response.errors);
        } else {
          setErros([response.message]);
        }
      }
    }
  }

  async function NumeroAtendimento() {
    const response = await Atendimento();
    if (response.sucesso) {
      setAtendimento(response.dados[0].numero);
    } else {
      if (response.errors.length > 1) {
        setErros(response.errors);
      } else {
        setErros([response.message]);
      }
    }
  }

  async function VerificarHorario(date, medico) {
    if (medicoId != "" && date != null) {
      const response = await HorariosVerifica(
        medicoId,
        moment(date).format("DD/MM/YYYY")
      );

      if (response.sucesso) {
        setHorario([]);
        if (response.dados[0].dados.length > 0) {
          const itens = [];
          for (var item of response.dados[0].dados) {
            itens.push({ Value: item.id, Text: item.horario });
          }
          setHorario(itens);
        }
        setDate(date);
      } else {
        if (response.errors.length > 1) {
          setErros(response.errors);
        } else {
          setErros([response.message]);
        }
      }
    }

    setMedicoId(medico);
    setDate(date);
  }

  async function Inserir() {
    const response = await InserirConsulta(
      numAtendimento,
      medicoId,
      moment(date).format("DD/MM/YYYY"),
      pacienteId
    );

    if (!response.sucesso) {
      setErros(response.errors);
      settypeAlert("error");
    } else {
      setErros([response.message]);
      setTimeout(() => {
        router.push("/Adm");
      }, 3000);
    }
  }

  return (
    <>
      <div className="mt-24 w-full">
        <div className="flex flex-row gap-2">
          <span className="text-2xl">Agendar paciente</span>
        </div>

        {/* <div id="alerta">
          {errors.map((item) => {
            <Alerta type={typeAlert} show={true}>
              {item}
            </Alerta>;
          })}
        </div> */}
        <div className="grid grid-cols-1 gap-4 py-5 ">
          <Input
            placeholder={"Atendimento"}
            disabled={true}
            value={numAtendimento}
          />
          {medico && (
            <Select
              placeholder={"Selecione um dentista"}
              value={medicoId}
              onChange={(e) => VerificarHorario(null, e.target.value)}
              data={medico}
              selectList={["id", "nomeMedico"]}
            />
          )}

          {pacientes && (
            <AutoComplete
              placeholder={"Selecione o nome do paciente"}
              data={pacientes}
              onChange={(value) => setPacienteId(value.value)}
              value={pacienteId}
            />
          )}
          <SelectDatas
            value={date}
            placeholder={"Data da consulta"}
            onChange={(date) => VerificarHorario(date, medicoId)}
          />

          {horario && (
            <Select
              placeholder={"Selecione um horario"}
              data={horario}
              selectList={["Value", "Text"]}
            />
          )}
        </div>
        <div className="flex flex-col gap-2 md:flex-row md:justify-row lg:flex-row xl:flex-row xl:justify-row">
          <Button onClick={Inserir}>Agendar</Button>
          <Ahref link={"/Adm"}>Voltar</Ahref>
        </div>
      </div>
    </>
  );
}

export default Consulta;
