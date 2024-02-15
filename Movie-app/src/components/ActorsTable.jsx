import { Fragment } from "react";
import { Table } from "semantic-ui-react";
import "../index.css";

function ActorList(props) {
  return (
    <Fragment>
      <h1
        style={{
          marginLeft: "30px",
        }}
      >
        Actor List
      </h1>
      <Table
        celled
        style={{
          marginLeft: "30px",
          marginTop: "30px",
          width: "1100px",
          border: "1px solid black",
        }}
      >
        <Table.Header>
          <Table.Row>
            <Table.HeaderCell>ID</Table.HeaderCell>
            <Table.HeaderCell>Name</Table.HeaderCell>
          </Table.Row>
        </Table.Header>
        <Table.Body>
          {props.actors.map((actor) => (
            <Table.Row key={actor.id}>
              <Table.Cell>{actor.id}</Table.Cell>
              <Table.Cell>{actor.name}</Table.Cell>
            </Table.Row>
          ))}
        </Table.Body>
      </Table>
    </Fragment>
  );
}

export default function ActorTable(props) {
  return <ActorList actors={props.actors}></ActorList>;
}
