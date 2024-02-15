import axios from "axios";
import "./App.css";
import NavBar from "./components/NavBar";
import MoviesDashboard from "./components/MoviesDashboard";
import { toast, ToastContainer } from "react-toastify";
function App() {
    const [movies, setMovies] = useState([]);
    const [movie, setMovie] = useState();
    const [actors, setActors] = useState([]);
    const [actor, setActor] = useState();
    const [showAddForm, setshowAddForm] = useState(false);
    const [showEditForm, setshowEditForm] = useState(false);

    const getToken = async (username, password, EmailAddress) => {
        try {
            const response = await axios.post(
                "http://localhost:5159/api/Authentication/Login",
                { username, password, EmailAddress }
            );

            if (response.status === 200) {
                const { token } = response.data; // Assuming response contains a token key
                return token;
            } else {
                throw new Error("Invalid credentials or login error");
            }
        } catch (error) {
            throw new Error("Error fetching token: " + error.message);
        }
    };

    const fetchData = async () => {
        const token = await getToken('user1','password1','');
        try {
            axios.get('http://localhost:5159/api/Movies', {
                headers: { Authorization: `Bearer ${token}` },
            }).then((response) => {
                setMovies(response.data);
            });
        } catch (error) {
            console.error('Error fetching data:', error);
        }

        try {
            axios.get('http://localhost:5159/api/Actor', {
                headers: { Authorization: `Bearer ${token}` },
            }).then((response) => {
                setActors(response.data);
            });
        } catch (error) {
            console.error('Error fetching data:', error);
        }
    }

        fetchData();

    function handleEditMovie(movie) {
        axios({
            method: "put",
            url: `http://localhost:5159/api/Movies/${movie.id}`,
            data: {
                Id: movie.id,
                Title: movie.title,
                MovieLanguage: movie.movieLanguage,
                ReleaseYear: movie.releaseYear,
                OTT: movie.ott,
            },
            config: {
                headers: {
                    Accept: "application/json",
                    "Content-Type": "application/json",
                },
            },
        })
            .then((response) => {
                console.log(response);
                toast.success("Movie updated successfully", {
                    position: toast.POSITION.TOP_RIGHT,
                });
            })
            .catch((error) => {
                console.log("the error has occured: " + error);
            });

        setMovies([...movies, movie]);
    }

    async function handleSumbit(movie) {
        const token = await getToken('user1', 'password1', '');
        const data = {
            Title: movie.title,
            MovieLanguage: movie.movieLanguage,
            ReleaseYear: movie.releaseYear,
            OTT: movie.ott,
        };
        axios({
            method: "post",
            url: "http://localhost:5159/api/Movies",
            headers: { Authorization: `Bearer ${token}` },
            data: data,
            config: {
                headers: {
                    Accept: "application/json",
                    "Content-Type": "application/json"
                },
            },
        })
            .then((response) => {
                console.log(response);
                toast.success("Movie added successfully", {
                    position: toast.POSITION.TOP_RIGHT,
                });
            })
            .catch((error) => {
                console.log("the error has occured: " + error);
            });

        setMovies([...movies, data]);
    }

    function addForm() {
        setshowEditForm(false);
        setshowAddForm(true);
    }

    function closeForm() {
        setshowAddForm(false);
        setshowEditForm(false);
        setMovie("");
    }

    function editForm(movie) {
        setMovie("");
        setshowAddForm(false);
        setshowEditForm(true);
        setMovie(movie);
    }

    function deleteMovie(id) {
        setshowEditForm(false);
        setMovie("");
        axios.delete(`http://localhost:5159/api/Movies/${id}`).then(() => {
            toast.success("Movie deleted successfully", {
                position: toast.POSITION.TOP_RIGHT,
            });
        });

        setMovies([...movies.filter((x) => x.id !== id)]);
    }

    return (
        <div>
            <NavBar addForm={addForm} />
            <h1>Movies Data</h1>
            <MoviesDashboard
                movies={movies}
                actors={actors}
                showAddForm={showAddForm}
                showEditForm={showEditForm}
                editForm={editForm}
                movie={movie}
                deleteMovie={deleteMovie}
                closeForm={closeForm}
                handleSumbit={handleSumbit}
                handleEditMovie={handleEditMovie}
            />
            <ToastContainer position="top-center" />
        </div>
    );
}

export default App;
