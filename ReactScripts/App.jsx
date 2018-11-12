
class App extends React.Component {
    render() {
        return (
            <CardList />
        );
    }
}

class CardList extends React.Component {
    render() {
        return(
           <p>It's something</p> 
        );
    }
}

ReactDOM.render(<App />, document.getElementById('content'));